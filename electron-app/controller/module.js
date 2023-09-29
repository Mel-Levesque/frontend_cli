document.addEventListener('DOMContentLoaded', function ("../projects//unMarche/unMarche.html") {
    //console.log(window.myUrl)
    // const myVariable = localStorage.getItem('projectUrl');
    // console.log(myVariable)

    // //ipcRenderer.send('call-my-function');

    // prepareFrame(localStorage.getItem('projectUrl'));

    // const modalIframe = document.getElementById('modalIframe')
    document.getElementById('modalIframe').src = localStorage.getItem('projectUrl');
    // function prepareFrame (url) {
        
    //   }
})