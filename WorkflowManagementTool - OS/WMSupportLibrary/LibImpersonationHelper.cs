using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Security.Principal;
using Microsoft.Win32.SafeHandles;

namespace WMSupportLibrary
{
    public sealed class SafeTokenHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        private SafeTokenHandle()
            : base(true)
        {
        }
        protected override bool ReleaseHandle()
        {
            return APILibrary.CloseHandle(handle);
        }
    }

    public class LibImpersonationHelper
    {
        [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
        public static void Impersonate(string domainName, string userName, string userPassword, Action actionToExecute)
        {
            SafeTokenHandle safeTokenHandle;
            try
            {
                // Call LogonUser to obtain a handle to an access token.
                bool returnValue = APILibrary.LogonUser(userName, domainName, userPassword,
                    APILibrary.LOGON32_LOGON_NEW_CREDENTIALS, APILibrary.LOGON32_PROVIDER_DEFAULT,
                    out safeTokenHandle);

                if (returnValue == false)
                {
                    int ret = Marshal.GetLastWin32Error();
                    throw new System.ComponentModel.Win32Exception(ret);
                }

                using (safeTokenHandle)
                {
                    // Use the token handle returned by LogonUser.
                    using (WindowsIdentity newId = new WindowsIdentity(safeTokenHandle.DangerousGetHandle()))
                    {
                        using (WindowsImpersonationContext impersonatedUser = newId.Impersonate())
                        {
                            actionToExecute();
                            if (impersonatedUser != null)
                                impersonatedUser.Undo();
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                //ex.HandleException();
                //On purpose: we want to notify a caller about the issue /Pavel Kovalev 9/16/2016 2:15:23 PM)/
                //throw;
            }
        }
    }
}
