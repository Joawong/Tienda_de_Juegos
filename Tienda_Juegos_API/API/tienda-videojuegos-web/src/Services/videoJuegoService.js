import axios from "axios";

const API_URL = "https://localhost:7195/api/videojuegos"; // ajusta el puerto al de tu API

export const obtenerVideoJuegos = () => axios.get(API_URL);
export const obtenerVideoJuegoPorId = (id) => axios.get(`${API_URL}/${id}`);
export const crearVideoJuego = (juego) => axios.post(API_URL, juego);
export const actualizarVideoJuego = (id, juego) => axios.put(`${API_URL}/${id}`, juego);
export const eliminarVideoJuego = (id) => axios.delete(`${API_URL}/${id}`);