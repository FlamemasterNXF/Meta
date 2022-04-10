import { DOMCacheGetOrSet } from "./Utils/Cache";
import { format, formatWhole, formatTime } from "./Utils/Formatting";
import { D, globalData as data, globalTemp as temp } from "./Data";

export function updateHTML(){
    //TODO
}

export function tabChangeHTML(oldPage:number, page:number){
    if (oldPage===-1){
        for (let i=1;i<3;i++){
            DOMCacheGetOrSet(`page${i}`).style.display = `none`
        }
        DOMCacheGetOrSet(`page${page}`).style.display = `flex`
    }
    else{
        DOMCacheGetOrSet(`page${oldPage}`).style.display = `none`
        DOMCacheGetOrSet(`page${page}`).style.display = `flex`
    }
}