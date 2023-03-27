import React, { useState } from 'react';
import { Route, Routes } from 'react-router-dom';
import AppRoutes from './AppRoutes';
import { Layout } from './components/Layout';
import { Login } from './components/Login';
import { UserContext } from './context/UserContext';
import './custom.css';


function App() {

    const [user, setUser] = useState({});

    if (!user.Logged) {
        return (
            <UserContext.Provider value={{
                user,
                setUser
            }}>
                <Login />
            </UserContext.Provider>
        )
    } else {
        return (
            <UserContext.Provider value={{
                user,
                setUser
            }}>
                <Layout>
                    <Routes>
                        {AppRoutes.map((route, index) => {
                            const { element, ...rest } = route;
                            return (element !== 'Login') ? <Route key={index} {...rest} element={element} /> : '';
                            /*return <Route key={index} {...rest} element={element} /> ;*/
                        })}
                    </Routes>
                </Layout>
            </UserContext.Provider>
        );
    }
}



export default App;