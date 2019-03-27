const bridge = require('node-dotnet-bridge')

const log = function(text) { console.log(text)}

exports.test = function (text) { 
    console.log("Vom addon " + text)
    bridge.initialize(log)
    bridge.testLogging("Das was äber schön 👌😁")
    bridge.unInitialize()
    console.log("Finished")
}