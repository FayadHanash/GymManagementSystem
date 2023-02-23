using GymManagementSystem;

/// <summary>
/// An own custom Message box class
/// </summary>
public class MsgBox
{
    /// <summary>
    /// Method that displays message
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="boxOption"></param>
    /// <param name="caption"></param>
    /// <returns></returns>
    public static bool Show(string msg, MessageBoxOption boxOption, string caption)
    {
        bool ok = false;
        Msg Msg = new Msg(msg, boxOption, caption);
        Msg.ShowDialog();
        if (Msg.Reslut == MsgBoxResult.Ok)
        {
            ok = true;
        }
        return ok;

    }
    /// <summary>
    /// Method that displays message
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public static bool Show(string msg) => Show(msg, MessageBoxOption.Ok, "");

    /// <summary>
    /// Method that displays message
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="caption"></param>
    /// <returns></returns>
    public static bool Show(string msg, string caption) => Show(msg, MessageBoxOption.Ok, caption);

    /// <summary>
    /// Method that displays message
    /// </summary>
    /// <param name="msg"></param>
    /// <returns></returns>
    public static bool Show(int msg) => Show(msg.ToString(), MessageBoxOption.Ok, "");

    /// <summary>
    /// Method that displays message
    /// </summary>
    /// <param name="msg"></param>
    /// <param name="caption"></param>
    /// <returns></returns>
    public static bool Show(int msg, string caption) => Show(msg.ToString(), MessageBoxOption.Ok, caption);
}

