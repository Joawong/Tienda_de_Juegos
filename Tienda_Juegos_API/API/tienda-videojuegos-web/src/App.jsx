import { BrowserRouter, Routes, Route } from "react-router-dom";
import Catalogo from "./pages/Catalogo";
import ListaVideoJuegos from "./pages/ListaVideoJuegos";
import FormularioVideoJuego from "./pages/FormularioVideoJuego";

function App() {
    return (
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Catalogo />} />
                <Route path="/admin" element={<ListaVideoJuegos />} />
                <Route path="/admin/nuevo" element={<FormularioVideoJuego />} />
                <Route path="/admin/editar/:id" element={<FormularioVideoJuego />} />
            </Routes>
        </BrowserRouter>
    );
}

export default App;