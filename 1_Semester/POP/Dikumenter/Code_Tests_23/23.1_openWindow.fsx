/// Listing 23.1 winforms/openWindow.fsx
/// Create the window and turn over control to the operating system.
/// Shown down-under:

// Create a window
let win = new System.Windows.Forms.Form ()
// Start the event-loop
System.Windows.Forms.Application.Run win