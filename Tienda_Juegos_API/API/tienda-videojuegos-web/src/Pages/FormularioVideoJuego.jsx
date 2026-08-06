import { useEffect, useState } from "react";
import { useNavigate, useParams, Link } from "react-router-dom";
import { obtenerVideoJuegoPorId, crearVideoJuego, actualizarVideoJuego } from "../services/videoJuegoService";
import "./Admin.css";

export default function FormularioVideoJuego() {
    const { id } = useParams();
    const navigate = useNavigate();
    const esEdicion = Boolean(id);

    const [form, setForm] = useState({
        titulo: "", plataforma: "", genero: "", precio: "", stock: "", fechaLanzamiento: ""
    });
    const [errores, setErrores] = useState({});

    useEffect(() => {
        if (esEdicion) {
            obtenerVideoJuegoPorId(id).then((res) => setForm(res.data));
        }
    }, [id]);

    const validar = () => {
        const nuevosErrores = {};
        if (!form.titulo.trim()) nuevosErrores.titulo = "El título es obligatorio";
        if (!form.plataforma.trim()) nuevosErrores.plataforma = "La plataforma es obligatoria";
        if (!form.precio || Number(form.precio) <= 0) nuevosErrores.precio = "El precio debe ser mayor a 0";
        if (form.stock === "" || Number(form.stock) < 0) nuevosErrores.stock = "El stock no puede ser negativo";
        setErrores(nuevosErrores);
        return Object.keys(nuevosErrores).length === 0;
    };

    const manejarEnvio = async (e) => {
        e.preventDefault();
        if (!validar()) return;

        if (esEdicion) {
            await actualizarVideoJuego(id, { ...form, id: Number(id) });
        } else {
            await crearVideoJuego(form);
        }
        navigate("/admin");
    };

    return (
        <div className="admin">
            <Link to="/admin" className="admin-volver">← Volver al listado</Link>

            <div className="admin-form-contenedor">
                <h2 className="admin-titulo" style={{ marginBottom: "1.5rem" }}>
                    {esEdicion ? "Editar" : "Nuevo"} videojuego
                </h2>
                <form onSubmit={manejarEnvio}>
                    <div className="admin-campo">
                        <label>Título</label>
                        <input value={form.titulo} onChange={(e) => setForm({ ...form, titulo: e.target.value })} />
                        {errores.titulo && <div className="admin-campo-error">{errores.titulo}</div>}
                    </div>
                    <div className="admin-campo">
                        <label>Plataforma</label>
                        <input value={form.plataforma} onChange={(e) => setForm({ ...form, plataforma: e.target.value })} />
                        {errores.plataforma && <div className="admin-campo-error">{errores.plataforma}</div>}
                    </div>
                    <div className="admin-campo">
                        <label>Género</label>
                        <input value={form.genero} onChange={(e) => setForm({ ...form, genero: e.target.value })} />
                    </div>
                    <div className="admin-campo">
                        <label>Precio</label>
                        <input type="number" value={form.precio} onChange={(e) => setForm({ ...form, precio: e.target.value })} />
                        {errores.precio && <div className="admin-campo-error">{errores.precio}</div>}
                    </div>
                    <div className="admin-campo">
                        <label>Stock</label>
                        <input type="number" value={form.stock} onChange={(e) => setForm({ ...form, stock: e.target.value })} />
                        {errores.stock && <div className="admin-campo-error">{errores.stock}</div>}
                    </div>
                    <div className="admin-campo">
                        <label>Fecha de lanzamiento</label>
                        <input type="date" value={form.fechaLanzamiento?.substring(0, 10) || ""} onChange={(e) => setForm({ ...form, fechaLanzamiento: e.target.value })} />
                    </div>
                    <button type="submit" className="admin-form-boton">Guardar</button>
                </form>
            </div>
        </div>
    );
}