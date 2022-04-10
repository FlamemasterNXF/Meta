import { DOMCacheGetOrSet } from "./Utils/Cache"
import {exportSave, fullReset, globalData, globalTemp, importSave} from "./Data"

export const generateEventHandlers = () => {
    DOMCacheGetOrSet("fullReset").addEventListener('click', () => fullReset());
    DOMCacheGetOrSet("export").addEventListener('click', () => exportSave());
    DOMCacheGetOrSet("import").addEventListener('click', () => importSave());
}