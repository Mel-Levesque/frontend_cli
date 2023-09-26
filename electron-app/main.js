const { app, BrowserWindow } = require('electron')

const createWindow = () => {
  const win = new BrowserWindow({
    width: 800,
    height: 600,
    webPreferences: {
      webSecurity: false
    }
  })

  win.loadFile('./view/index.html')
}

app.on('window-all-closed', () => {
  if (process.platform !== 'darwin') app.quit()
})

app.whenReady().then(() => {
  createWindow()

  app.on('activate', () => {
    if (BrowserWindow.getAllWindows().length === 0) {
      createWindow()
    }
  })
})

// const command = 'mjj test Un magasins de tests de lunettes et de lasers pour enfants'

// exec(command, (error, stdout, stderr) => {
//   console.log('COMMANDE EXECUTE !')
//   if (error) {
//     console.error(`Error executing ${command}: ${error.message}`)
//     return
//   }

//   console.log(`Command output:\n${stdout}`)
//   if (stderr) {
//     console.error(`Command error:\n${stderr}`)
//   }
// })

console.log('Hello from Electron 👋')
