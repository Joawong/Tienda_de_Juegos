import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import { obtenerVideoJuegos, eliminarVideoJuego } from "../services/videoJuegoService";
import "./Admin.css";

export default function ListaVideoJuegos() {
    const [juegos, setJuegos] = useState([]);
    const [error, setError] = useState("");

    const cargarJuegos = async () => {
        try {
            const respuesta = await obtenerVideoJuegos();
            setJuegos(respuesta.data);
        } catch {
            setError("No se pudieron cargar los videojuegos.");
        }
    };

    useEffect(() => { cargarJuegos(); }, []);

    const manejarEliminar = async (id) => {
        if (!confirm("¿Seguro que deseas eliminar este videojuego?")) return;
        await eliminarVideoJuego(id);
        cargarJuegos();
    };

    return (
        <div className="admin">
            <Link to="/" className="admin-volver">← Volver al catálogo</Link>

            <div className="admin-encabezado">
                <h1 className="admin-titulo2">Administración de videojuegos</h1>
                <Link to="/admin/nuevo" className="admin-boton-nuevo">+ Agregar videojuego</Link>
            </div>

            {error && <div className="admin-error">{error}</div>}

            <div className="admin-tabla-contenedor">
                <table className="admin-tabla">
                    <thead>
                        <tr>
                            <th>Título</th><th>Plataforma</th><th>Género</th><th>Precio</th><th>Stock</th><th></th>
                        </tr>
                    </thead>
                    <tbody>
                        {juegos.map((j) => (
                            <tr key={j.id}>
                                <td>{j.titulo}</td>
                                <td><span className="admin-badge">{j.plataforma}</span></td>
                                <td>{j.genero}</td>
                                <td className="admin-precio">₡{j.precio}</td>
                                <td>{j.stock}</td>
                                <td>
                                    <div className="admin-acciones">
                                        <Link to={`/admin/editar/${j.id}`} className="admin-btn-editar">Editar</Link>
                                        <button className="admin-btn-eliminar" onClick={() => manejarEliminar(j.id)}>Eliminar</button>
                                    </div>
                                </td>
                            </tr>
                        ))}
                    </tbody>
                </table>
                {juegos.length === 0 && !error && (
                    <p className="admin-vacio">Todavía no hay videojuegos registrados.</p>
                )}
            </div>
        </div>
    );
}