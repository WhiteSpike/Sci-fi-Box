using LethalCompanyInputUtils.Api;
using UnityEngine.InputSystem;
using ScifiBox.Util;

namespace ScifiBox.Input
{
    /// <summary>
    /// Class which stores the used key binds in the mod
    /// </summary>
    internal class IngameKeybinds : LcInputActions
    {
        public static IngameKeybinds Instance;
        /// <summary>
        /// Asset used to store all the input bindings defined for our controls
        /// </summary>
        internal static InputActionAsset GetAsset()
        {
            return Instance.Asset;
        }

        /// <summary>
        /// Input binding used to trigger the drop all items action
        /// </summary>
        [InputAction(Constants.DROP_ALL_ITEMS_SCIFI_BOX_DEFAULT_KEYBIND, Name = Constants.DROP_ALL_ITEMS_SCIFI_BOX_KEYBIND_NAME)]
        public InputAction DropAllItemsKey { get; set; }

    }
}
