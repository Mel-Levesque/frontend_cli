const fs = require('fs')
const { Grid } = require('gridjs')
const path = require('path')
const url = require('url')
const remote = require('@electron/remote')
// const modal = require('electron-modal');

// const URI = fs.readdirSync(`${process.cwd()}/projects/cmdkhgmws/cmdkhgmws.html`);

document.addEventListener('DOMContentLoaded', function () {
  // Get a reference to the button element by its ID
  const createProjectButton = document.getElementById('createProjectButton')
  // const gridJs = document.getElementById('gridJs')

  // Add a click event listener to the button
  createProjectButton.addEventListener('click', createNewProj)
  // gridJs.addEventListener('click', previewProject)

  function createNewProj () {
    // TODO: call CLI command
    document.location.href = '../view/newProject.html'
  }

  getProjects()

  function getProjects () {
    const folders = fs.readdirSync(process.cwd())
    console.log('folders')
    console.log(folders)
    // if folder project exists then list all projects
    if (folders.includes('projects')) {
      console.log('Youpi ça includes !')
      const projectFolders = fs.readdirSync(`${process.cwd()}/projects`)
      console.log('projectFolders')
      console.log(projectFolders)
      addTable(projectFolders)
    }
  }

  function addTable (projectFolders) {
  // const projectFolders = [
  //   ['Item 1', '<iframe class="preview-iframe" src="D:/MDS/Dev_Natif/projet_template/frontend_cli/electron-app/projects/cmdkhgmws/cmdkhgmws.html"></iframe>'],
  //   ['Item 2', '<iframe class="preview-iframe" src="file2.html"></iframe>'],
  //   ['Item 3', '<iframe class="preview-iframe" src="file3.html"></iframe>'],
  //   // Add more data here
  // ];

    // Split the data into rows with a maximum of 3 elements per row
    const rows = []
    for (let i = 0; i < projectFolders.length; i += 3) {
      const row = projectFolders.slice(i, i + 3)
      rows.push(row)
    }

    // Create a new instance of Grid.js
    const grid = new Grid({
    // columns: ['Column 1', 'Column 2', 'Column 3'],
      data: rows
    }).render(document.getElementById('grid-container'))

    document.getElementById('grid-container').addEventListener('click', (event) => {
      const cell = event.target

      // Check if the clicked element is a cell (td)
      if (cell.tagName === 'TD') {
      // cell.style.backgroundColor = 'lightblue'; // Change this color as needed
      // document.location.href = `../projects/${cell.innerHTML}/${cell.innerHTML}.html`;
        const url = `../projects/${cell.innerHTML}/${cell.innerHTML}.html`;
        localStorage.setItem('projectUrl', url);
        const myVariable = localStorage.getItem('projectUrl');
        console.log("myVariable = "+myVariable);

        createWindow(url)
      // createModal();
      }
    })
  }

  function prepareFrame (url) {
    const ifrm = document.createElement('iframe')
    ifrm.setAttribute('src', url)
    ifrm.style.width = '600px'
    ifrm.style.height = '400px'
    document.body.appendChild(ifrm)
  }

  function setIframeUrl (htmlUrl) {
    const modalWindow = remote.getCurrentWindow()
    const modalWebContents = modalWindow.webContents
  
    // Find the iframe element in the modal and set its src attribute
    // modalWebContents.executeJavaScript(`
    //   document.getElementById('modalIframe').src = '${htmlUrl}';
    // `)
  }

  /** Modal **/
  function createWindow (htmlUrl) {
    // Create a new browser window for the modal
    const modalWindow = new remote.BrowserWindow({
      parent: remote.getCurrentWindow(),
      modal: true,
      show: false,
      width: 600,
      height: 400,
      webPreferences: {
        nodeIntegration: true
      }
    })

    // Load the modal HTML file into the modal window
    modalWindow.loadURL(
      url.format({
        pathname: path.join(__dirname, 'modal.html'),
        protocol: 'file:',
        slashes: true
      })
    )

    // Show the modal window when it's ready to be displayed
    modalWindow.once('ready-to-show', () => {
      modalWindow.show();
      setIframeUrl(htmlUrl);
    })

    // Handle the "Retour" button click event inside the modal
    modalWindow.webContents.on('did-finish-load', () => {
      modalWindow.webContents.on('click', (event, elementId) => {
        if (elementId === 'retourButton') {
          modalWindow.close()
        }
      })
    })

  }
  // let mainWindow;
  // let modalWindow;

  // function createWindow() {
  //   mainWindow = new remote.BrowserWindow({ width: 800, height: 600 });
  //   mainWindow.loadFile('index.html'); // Load your main HTML file

  //   mainWindow.on('closed', function () {
  //     mainWindow = null;
  //   });
  // }

  // function createModal() {
  //   modalWindow = new remote.BrowserWindow({
  //     parent: mainWindow,
  //     modal: true,
  //     show: false,
  //     width: 600,
  //     height: 400,
  //     webPreferences: {
  //       nodeIntegration: true,
  //     },
  //   });

  //   modalWindow.loadURL(
  //     url.format({
  //       pathname: path.join(__dirname, 'cmdkhgmws.html'),
  //       protocol: 'file:',
  //       slashes: true,
  //     })
  //   );

  //   modalWindow.once('ready-to-show', () => {
  //     modalWindow.show();
  //   });

  //   // Handle the "Retour" button click event
  //   modalWindow.webContents.on('did-finish-load', () => {
  //     modalWindow.webContents.on('click', (event, elementId) => {
  //       if (elementId === 'retourButton') {
  //         modalWindow.close();
  //       }
  //     });
  //   });
  // }

  // generateGrid();
  // function generateGrid(){
  //   //setup data
  //   let rowData = [];
  //   const columnDefs = [
  //     { field: "task", editable: false, flex: 1 }
  //   ];
  //   const gridOptions = {
  //     columnDefs,
  //     rowData,
  //   };

  //   //create grid
  //   const setupGrid = () => {
  //     const gridDiv = document.getElementById("gridJs");

  //     new Grid(gridDiv, gridOptions);
  //   };
  // }

  // var childs = document.getElementById('grid-container').children;
  //     for (var i = 0; childs[i]; i++) {
  //     childs[i].onclick = function () {
  //         this.style.color = "#187ABC";
  //     }
  //   }

  // function previewProject(){

  // }

  // function generateGrid(){
  //   var e = document.body;
  //   const v = 5; // whatever you want to append the rows to:
  //     for(var i = 0; i < v; i++){
  //       var row = document.createElement("div");
  //       row.className = "row";
  //       for(var x = 1; x <= v; x++){
  //           var cell = document.createElement("div");
  //           cell.className = "gridsquare";
  //           cell.innerText = (i * v) + x;
  //           row.appendChild(cell);
  //       }
  //       e.appendChild(row);
  //     }
  //     document.getElementById("code").innerText = e.innerHTML;
  // }
})
