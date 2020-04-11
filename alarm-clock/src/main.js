const { app, BrowserWindow } = require('electron');
const path = require('path');

function createWindow() {
    let win = new BrowserWindow({
        width: 600,
        height: 600,
        title: 'Alarm Clock',
        frame: false,
        resizable: false,
        webPreferences: {
            nodeIntegration: true,
        },
    });
    
    // TODO - Start localhost
    win.loadFile(path.join(__dirname, 'presentation', 'build', 'index.html'));
}

app.whenReady().then(createWindow);

app.on('window-all-closed', () => {
    if (process.platform !== 'darwin') {
        app.quit()
    }
});

app.on('before-quit', () => {
    // TODO - Terminate localhost
});

app.on('activate', () => {
    if (BrowserWindow.getAllWindows().length === 0) {
        createWindow()
    }
});