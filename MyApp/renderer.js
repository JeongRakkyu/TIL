function loadDoc() {
    const { ipcRenderer } = require('electron')
    ipcRenderer.on('ajaxCall', (event, arg) => {
        test1234 = arg;
    })
    ipcRenderer.send('ajax', 'test')
}