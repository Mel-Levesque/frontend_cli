//const { ipcRenderer } = require('electron');
const { exec } = window.require('child_process');
const remote = require('@electron/remote');
const { dialog } = remote;

document.addEventListener('DOMContentLoaded', function () {
  // Get a reference to the button element by its ID
  const backBtn = document.getElementById('back')
  const createProjectBtn = document.getElementById('createProject')

  // Add a click event listener to the button
  backBtn.addEventListener('click', goBack)
  createProjectBtn.addEventListener('click', createProject)

  function goBack () {
    document.location.href = '../view/index.html'
  }

  function createProject () {
    // get form infos
    let projectName = document.getElementById('projectName').value
    const projectDesc = document.getElementById('projectDesc').value
    const errorMessage = document.getElementById('errorMessage');

    //test spacial characters excluding '-' and '_'
    //if false there are no special characters
    //var regex = /[^a-zA-Z0-9_\-]/;
    var regex = /[!@#$%^&*()_+={}\[\]:;<>,.?~\\|]/;
    // check infos
    if (projectName !== undefined && projectName !== '' && !regex.test(projectName)) {
      console.log(regex.test(projectName));
      if (projectDesc !== undefined && projectDesc !== '') {
        // replace all spaces in projectName by unerscore (because of the cli)
        projectName = projectName.replace(/\s+/g, '_')
        if (projectName.charAt(projectName.length - 1) === '_') {
          projectName.slice(0, -1)
        }
        // CLI command
        CLICommand(projectName, projectDesc)
      }else{
        dialog.showErrorBox("Erreur","La description du projet ne peut pas être vide");
      }
    }else{
      dialog.showErrorBox("Erreur","La description du projet ne peut pas être vide");
    }
  }

  function CLICommand (projectName, projectDesc) {
    //RunCommand().executeCommand();
    const command = 'mjj ' + projectName + ' ' + projectDesc

    exec(command, (error, stdout, stderr) => {
      if (error) {
        console.error(`Error executing ${command}: ${error.message}`)
        return
      }

      console.log(`Command output:\n${stdout}`)
      if (stderr) {
        console.error(`Command error:\n${stderr}`)
      }
    })

    //dialog.showMessageBox("Super!", "Template créé avec succès !");
    const options = {
      type: 'question',
      buttons: ['Ok'],
      defaultId: 2,
      title: 'Super !',
      message: 'Template créé avec succès !'
    };
  
    dialog.showMessageBox(null, options, (response) => {
      console.log(response);
    });
    location.reload();
  }
})
