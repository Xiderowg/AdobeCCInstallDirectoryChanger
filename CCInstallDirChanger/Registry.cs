using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace CCInstallDirChanger
{
    /// <summary>
    /// Registry Edit Class
    /// </summary>
    public class RegistryEdit
    {
        private RegistryKey CurrentKey;
        public RegistryEdit(RegistryKey KeyMain)
        {
            CurrentKey = KeyMain;
        }

        /// <summary>
        /// Create a Subitem with given path
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public bool CreateItem(string Path)
        {
            try
            {
                using (RegistryKey Key = CurrentKey.CreateSubKey(Path))
                {

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Set a key with given path, value and value type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Path"></param>
        /// <param name="KeyName"></param>
        /// <param name="KeyValue"></param>
        /// <param name="ValueKind"></param>
        /// <returns></returns>
        public bool SetKey<T>(string Path, string KeyName, T KeyValue, RegistryValueKind ValueKind)
        {
            try
            {
                using (RegistryKey Key = CurrentKey.OpenSubKey(Path, true))
                {
                    Key.SetValue(KeyName, KeyValue, ValueKind);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Delete an item with given path
        /// </summary>
        /// <param name="Path"></param>
        /// <returns></returns>
        public bool DeleteItem(string Path)
        {
            try
            {
                CurrentKey.DeleteSubKey(Path, true);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Delete a value with given Path and Value Name
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="KeyName"></param>
        /// <returns></returns>
        public bool DeleteKey(string Path, string KeyName)
        {
            try
            {
                using (RegistryKey Key = CurrentKey.OpenSubKey(Path, true))
                {
                    Key.DeleteValue(KeyName, true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Get Value of Given ValueName
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Path"></param>
        /// <param name="KeyName"></param>
        /// <returns></returns>
        public T GetKeyValue<T>(string Path, string KeyName)
        {
            try
            {
                using (RegistryKey Key = CurrentKey.OpenSubKey(Path, true))
                {
                    var Val = Key.GetValue(KeyName, null, RegistryValueOptions.DoNotExpandEnvironmentNames);
                    if (Val != null)
                    {
                        T result = (T)Convert.ChangeType(Val, typeof(T));
                        return result;
                    }
                    throw new KeyNotFoundException("Cannot find the value");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return default(T);
            }
        }


    }
}
