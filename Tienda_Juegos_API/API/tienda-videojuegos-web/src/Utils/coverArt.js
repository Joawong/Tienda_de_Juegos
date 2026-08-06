const DEGRADADOS = [
    ["#1b2838", "#2a4d69"],
    ["#3c1053", "#ad5389"],
    ["#134e5e", "#71b280"],
    ["#0f2027", "#2c5364"],
    ["#603813", "#b29f94"],
    ["#360033", "#0b8793"],
];

export function obtenerPortada(titulo) {
    let hash = 0;
    for (let i = 0; i < titulo.length; i++) {
        hash = titulo.charCodeAt(i) + ((hash << 5) - hash);
    }
    const indice = Math.abs(hash) % DEGRADADOS.length;
    const [inicio, fin] = DEGRADADOS[indice];
    const inicial = titulo.trim().charAt(0).toUpperCase() || "?";
    return { inicio, fin, inicial };
}