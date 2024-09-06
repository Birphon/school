var messages = document.getElementsByClassName('msg')
var currentMessageIndex = 0
var maxIndex = messages.length
var showDuration = 2000

function hideAllMessages () {
  for (let msg of  messages){
	msg.hidden = true
  }
}

function showNextMessage () {
  console.log('tick')
  messages[currentMessageIndex].hidden = true
  currentMessageIndex += 1
  if (currentMessageIndex == maxIndex) {
	currentMessageIndex = 0
  }
  messages[currentMessageIndex].hidden = false
}

function startSlideShow () {
  console.log('starting')
  hideAllMessages()
  setInterval(showNextMessage, showDuration)
}

//window.onload = start