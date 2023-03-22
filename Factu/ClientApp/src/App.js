import React, { useState } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import { Layout } from './components/Layout';
import { Login } from './components/Login';
import './custom.css';


function App() {

    const [token, setToken] = useState();

    if (!token) {
        return <Login setToken={setToken} />
    } else {
        return (
            <Layout setToken={setToken}>
                <Routes>
                    {AppRoutes.map((route, index) => {
                        const { element, ...rest } = route;
                        return (element !== 'Login') ? <Route key={index} {...rest} element={element} /> : '';
                        /*return <Route key={index} {...rest} element={element} /> ;*/
                    })}
                </Routes>
            </Layout>
        );
    }
}



export default App;