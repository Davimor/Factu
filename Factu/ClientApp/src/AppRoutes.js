import { Home } from "./components/Home";
import { Login } from "./components/Login";
import { Counter } from "./components/Counter";

const AppRoutes = [
    {
        index: true,
        element: <Home />
    },
    {
        path: '/counter',
        element: <Counter />
    },
    {
        path: '/login',
        element: <Login setToken={ () => ''} />
    }
];

export default AppRoutes;
