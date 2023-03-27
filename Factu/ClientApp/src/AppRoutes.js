import { Home } from "./components/Home";
import { Login } from "./components/Login";
import { Datos } from "./components/Datos";

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/datos',
        element: <Datos />
    },
    {
        path: '/login',
        element: <Login setToken={ () => ''} />
    }
];

export default AppRoutes;
