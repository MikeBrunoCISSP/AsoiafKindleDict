namespace AsoiafKindleDict.Api;

/// <summary>
/// Contains enumeration of health alerts for NTDS certificate templates.
/// <para>This enumeration has a <see cref="FlagsAttribute"/> attribute that allows a bitwise combination of its member values.</para>
/// </summary>
[Flags]
public enum AppRights {
    /// <summary>
    /// No privileges are required for read access.
    /// </summary>
    Readonly    = 0,
    /// <summary>
    /// A super admin can add and remove users and change other users' rights.
    /// </summary>
    Admin  = 0x1,
    /// <summary>
    /// An editor can change existing entries and approve new entries.
    /// </summary>
    Editor      = 0x2,
    /// <summary>
    /// A contributor can create new entries, but they are subject to approval.
    /// </summary>
    Contributor = 0x4
}
