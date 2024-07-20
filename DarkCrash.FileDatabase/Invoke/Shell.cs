using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DarkCrash.FileDatabase.Invoke
{
    /// <summary>
    /// Native Method win api
    /// </summary>
    internal class NavtiveShell
    {
        /// <summary>
        /// SHFILEOPSTRUCT.fFlags and IFileOperation::SetOperationFlags() flag values
        /// </summary>
        [Flags]
        public enum FILEOP_FLAGS : ushort
        {
            FOF_MULTIDESTFILES = 0x1,
            FOF_CONFIRMMOUSE = 0x2,
            // don't display progress UI (confirm prompts may be displayed still)
            FOF_SILENT = 0x4,
            // automatically rename the source files to avoid the collisions
            FOF_RENAMEONCOLLISION = 0x8,
            // don't display confirmation UI, assume "yes" for cases that can be bypassed, "no" for those that can not
            FOF_NOCONFIRMATION = 0x10,
            // Fill in SHFILEOPSTRUCT.hNameMappings
            // Must be freed using SHFreeNameMappings
            FOF_WANTMAPPINGHANDLE = 0x20,
            // enable undo including Recycle behavior for IFileOperation::Delete()
            FOF_ALLOWUNDO = 0x40,
            // only operate on the files (non folders), both files and folders are assumed without this
            FOF_FILESONLY = 0x80,
            // means don't show names of files
            FOF_SIMPLEPROGRESS = 0x100,
            // don't dispplay confirmatino UI before making any needed directories, assume "Yes" in these cases
            FOF_NOCONFIRMMKDIR = 0x200,
            // don't put up error UI, other UI may be displayed, progress, confirmations
            FOF_NOERRORUI = 0x400,
            // dont copy file security attributes (ACLs)
            FOF_NOCOPYSECURITYATTRIBS = 0x800,
            // don't recurse into directories for operations that would recurse
            FOF_NORECURSION = 0x1000,
            // don't operate on connected elements ("xxx_files" folders that go with .htm files)
            FOF_NO_CONNECTED_ELEMENTS = 0x2000,
            // during delete operation, warn if object is being permanently destroyed instead of recycling (partially overrides FOF_NOCONFIRMATION)
            FOF_WANTNUKEWARNING = 0x4000,
            // deprecated; the operations engine always does the right thing on FolderLink objects (symlinks, reparse points, folder shortcuts)
            FOF_NORECURSEREPARSE = 0x8000,
            // don't display any UI at all
            FOF_NO_UI = FOF_SILENT | FOF_NOCONFIRMATION | FOF_NOERRORUI | FOF_NOCONFIRMMKDIR
        }

        /// <summary>
        /// Shell File Operations
        /// </summary>
        public enum FileFuncFlags
        {
            FO_MOVE = 0x1,
            FO_COPY = 0x2,
            FO_DELETE = 0x3,
            FO_RENAME = 0x4
        }

        // implicit parameters are:
        //      if pFrom or pTo are unqualified names the current directories are
        //      taken from the global current drive/directory settings managed
        //      by Get/SetCurrentDrive/Directory
        //
        //      the global confirmation settings
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct SHFILEOPSTRUCTA
        {
            public IntPtr hwnd;
            [MarshalAs(UnmanagedType.U4)] public FileFuncFlags wFunc;
            [MarshalAs(UnmanagedType.LPWStr)] public string pFrom;
            [MarshalAs(UnmanagedType.LPWStr)] public string pTo;
            [MarshalAs(UnmanagedType.U2)] public FILEOP_FLAGS fFlags;
            [MarshalAs(UnmanagedType.Bool)] public bool ffAnyOperationsAborted;
            public IntPtr hNameMappings;
            [MarshalAs(UnmanagedType.LPWStr)] public string lplpszProgressTitle;
        }

        [DllImport("shell32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern int SHFileOperation([In] ref SHFILEOPSTRUCTA lpFileOp);
    }
}
