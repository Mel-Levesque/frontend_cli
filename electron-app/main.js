const { app, BrowserWindow } = require('electron')
const { exec } = require('child_process')
const remoteMain = require('@electron/remote/main');
remoteMain.initialize();

const createWindow = () => {
  const win = new BrowserWindow({
    width: 800,
    height: 600,
    webPreferences: {
      webSecurity: false,
      nodeIntegration: true,
      contextIsolation: false
    }
  })

  //for chrome devTools
  win.webContents.openDevTools()

  win.loadFile('./view/index.html')

  // enable remot to use dialog
  remoteMain.enable(win.webContents)

  win.webContents.on('new-window', (event, url) => {
    event.preventDefault()
    const win = new BrowserWindow({show: false})
    win.once('ready-to-show', () => win.show())
    win.loadURL(url)
    event.newGuest = win
  })

}

app.on('window-all-closed', () => {
  if (process.platform !== 'darwin') app.quit()
})

app.commandLine.appendSwitch("ignore-certificate-errors");

app.whenReady().then(() => {
  createWindow()

  app.on('activate', () => {
    if (BrowserWindow.getAllWindows().length === 0) {
      createWindow()
    }
  })


  app.on('ready', () => {  
    //const { dialog } = require('electron')
    //dialog.showMessageBox(null);

    session.defaultSession.webRequest.onBeforeSendHeaders(
      filter,
      (details, callback) => {
        console.log(details);
        details.requestHeaders['Origin'] = 'file:///D:/MDS/Dev_Natif/projet_template/frontend_cli/electron-app';
        callback({ requestHeaders: details.requestHeaders });
      }
    );
  
    session.defaultSession.webRequest.onHeadersReceived(
      filter,
      (details, callback) => {
        console.log(details);
        details.responseHeaders['Access-Control-Allow-Origin'] = [
          'capacitor-electron://-'
        ];
        callback({ responseHeaders: details.responseHeaders });
      }
    );
  
    myCapacitorApp.init();
  });
})

//executeCommand();

// function executeCommand(){
//   const command = 'mjj test Un magasins de tests de lunettes et de lasers pour enfants'

//   exec(command, (error, stdout, stderr) => {
//     console.log('COMMANDE EXECUTE !')
//     if (error) {
//       console.error(`Error executing ${command}: ${error.message}`)
//       return
//     }
  
//     console.log(`Command output:\n${stdout}`)
//     if (stderr) {
//       console.error(`Command error:\n${stderr}`)
//     }
//   })
// }

console.log('Hello from Electron 👋')
