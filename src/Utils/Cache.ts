//Credit to Khafra and Platonic
/**
 * A cache for DOM elements
 */
export const DOMCache = new Map<string, HTMLElement>();

export const DOMCacheGetOrSet = (id: string) => {
    const cachedEl = DOMCache.get(id);
    if (cachedEl) return cachedEl;

    const el : any = document.getElementById(id);
    DOMCache.set(id, el);
    return el;
}