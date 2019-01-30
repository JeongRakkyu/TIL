const { ipcMain, app, BrowserWindow } = require('electron')

// window 객체는 전역 변수로 유지. 이렇게 하지 않으면, 
// 자바스크립트 객체가 가비지 콜렉트될 때 자동으로 창이 닫힐 것입니다.
let win

function createWindow () {
  // 브라우저 창을 생성합니다.
  win = new BrowserWindow({ width: 1000, height: 800 })
  
  // 앱의 index.html 파일을 로드합니다.
  win.loadFile('index.html')

  // 창이 닫힐 때 발생합니다
  win.on('closed', () => {
    // window 객체에 대한 참조해제. 여러 개의 창을 지원하는 앱이라면 
    // 창을 배열에 저장할 수 있습니다. 이곳은 관련 요소를 삭제하기에 좋은 장소입니다.
    win = null
  })
}

// 이 메서드는 Electron이 초기화를 마치고 
// 브라우저 창을 생성할 준비가 되었을 때  호출될 것입니다.
// 어떤 API는 이 이벤트가 나타난 이후에만 사용할 수 있습니다.
app.on('ready', createWindow)

// 모든 창이 닫혔을 때 종료.
app.on('window-all-closed', () => {
  // macOS에서는 사용자가 명확하게 Cmd + Q를 누르기 전까지는
  // 애플리케이션이나 메뉴 바가 활성화된 상태로 머물러 있는 것이 일반적입니다.
  if (process.platform !== 'darwin') {
    app.quit()
  }
})

app.on('activate', () => {
  // macOS에서는 dock 아이콘이 클릭되고 다른 윈도우가 열려있지 않았다면
  // 앱에서 새로운 창을 다시 여는 것이 일반적입니다.
  if (win === null) {
    createWindow()
  }
})

// 이 파일 안에 당신 앱 특유의 메인 프로세스 코드를 추가할 수 있습니다. 별도의 파일에 추가할 수도 있으며 이 경우 require 구문이 필요합니다.

ipcMain.on('ajax', (event, arg) => {
  const request = require('request')
  const crypto = require('crypto')

  const apiUrl = "https://api.naver.com"
  const apiKey = "010000000003f329fae1ce6b65bf4fe9fa35d395c836ac733757a789a87e9d002b96a7d669"
  const secretKey = "AQAAAAAD8yn64c5rZb9P6fo105XIJ81faSqrc/+GbNx2FRCbQw=="
  const customerId = 1562246

  let timestamp = new Date().getTime();
  let hmac = crypto.createHmac('sha256', secretKey)
  let signature = hmac.update(timestamp + "." + "GET" + "." + "/keywordstool").digest('base64')

  request.get({
    url: apiUrl + "/keywordstool" + "?hintKeywords=face&showDetail=1",
    body: JSON.stringify("hintKeywords=아토미&showDetail=1"),
    headers: {
      'X-API-KEY': apiKey,
      'X-Timestamp': timestamp,
      'X-Customer': customerId,
      'X-Signature': signature,
      'Content-Type': 'application/json'
    }
  },
  (error, response, body) => {
    console.log(response.statusCode)
    console.log(JSON.parse(body))
    event.sender.send('ajaxCall', JSON.parse(body))
  })
})