import { useEffect, useState } from "react";
import { obtenerVideoJuegos } from "../services/videoJuegoService";
import { obtenerPortada } from "../utils/coverArt";
import "./Catalogo.css";
import { Link } from "react-router-dom";
export default function Catalogo() {
    const [juegos, setJuegos] = useState([]);
    const [busqueda, setBusqueda] = useState("");
    const [error, setError] = useState("");

    useEffect(() => {
        obtenerVideoJuegos()
            .then((res) => setJuegos(res.data))
            .catch(() => setError("No se pudo cargar el catálogo."));
    }, []);

    const juegosFiltrados = juegos.filter((j) =>
        j.titulo.toLowerCase().includes(busqueda.toLowerCase())
    );

    return (
        <div className="catalogo">
            <header className="catalogo-nav">
                <span className="catalogo-logo">Biblioteca de Juegos</span>
                <div className="catalogo-nav-derecha">
                    <input
                        className="catalogo-buscar"
                        placeholder="Buscar videojuegos..."
                        value={busqueda}
                        onChange={(e) => setBusqueda(e.target.value)}
                    />
                    <Link to="/admin" className="catalogo-boton-admin">Administración</Link>
                </div>
            </header>

            {error && <p className="catalogo-error">{error}</p>}

            <div className="catalogo-grid">
                {juegosFiltrados.map((juego) => {
                    const portada = obtenerPortada(juego.titulo);
                    return (
                        <div className="catalogo-card" key={juego.id}>
                            <div
                                className="catalogo-portada"
                                style={{
                                    background: `linear-gradient(160deg, ${portada.inicio}, ${portada.fin})`,
                                }}
                            >
                                <span className="catalogo-inicial">{portada.inicial}</span>
                            </div>
                            <div className="catalogo-info">
                                <p className="catalogo-titulo">{juego.titulo}</p>
                                <span className="catalogo-plataforma">{juego.plataforma}</span>
                                <div className="catalogo-pie">
                                    <span className="catalogo-genero">{juego.genero}</span>
                                    <span className="catalogo-precio">₡{juego.precio}</span>
                                </div>
                            </div>
                        </div>
                    );
                })}
            </div>

            {juegosFiltrados.length === 0 && !error && (
                <p className="catalogo-vacio">No encontramos videojuegos con ese nombre.</p>
            )}
        </div>
    );
}