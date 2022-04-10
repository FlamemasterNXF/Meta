import { globalData, load } from "./Data";
import { generateEventHandlers } from "./EventListeners";
import {tabChangeHTML, updateHTML} from "./UpdateHTML";

function calcLoop(){
}

function mainLoop(){
    let diff:number
    diff = (Date.now()-globalData.time)/1000
    globalData.time = Date.now()
    calcLoop()
    updateHTML()
}

export function switchTab(i:number){
    let tempOldPage = globalData.currentTab
    globalData.currentTab = i
    tabChangeHTML(tempOldPage, i)
}

window.setInterval(function(){
    mainLoop()
}, 50);
window.onload = function (){
    load()
    tabChangeHTML(-1,globalData.currentTab)
    generateEventHandlers()
}