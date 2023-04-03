import { Home } from "./components/Home";
import { Login } from "./components/Login";
import { Datos } from "./components/Datos";
import { Clientes } from "./components/Clientes";

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/datos',
        element: <Datos />
    }, {
        path: '/client',
        element: <Clientes />
    },
    {
        path: '/login',
        element: <Login setToken={ () => ''} />
    }
];

export default AppRoutes;
