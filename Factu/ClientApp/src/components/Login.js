import React, { useContext, useEffect } from 'react';
import { useGoogleLogin } from '@react-oauth/google';
import { UserContext } from '../context/UserContext';


export const Login = () => {

    const { user, setUser } = useContext(UserContext);

    const setLogin = async (access_token) => {

        const apires = await fetch("/api/user/Login?access_token=" + access_token);

        if (apires.ok) {
            const data = await apires.json();
            setUser({
                Id: data.id,
                Email: data.email,
                Name: data.name,
                Apellido: data.apellido,
                Fullname: data.fullname,
                Logged: true,
                Token: access_token
            });
            localStorage.setItem('userInfo', access_token);
        }
    }

    const login = useGoogleLogin({
        onSuccess: response => {
            setLogin(response.access_token);
        }
    });

    useEffect(() => {
        if (localStorage.getItem('userInfo') != null) {
            setLogin(localStorage.getItem('userInfo'));
        }
    });

    return (<div>
        <section className="vh-100">
            <div className="container py-5 h-100">
                <p>{user.Logged}</p>
                <div className="row d-flex align-items-center justify-content-center h-100">
                    <div className="col-md-8 col-lg-7 col-xl-6">
                        <img src={'https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-login-form/draw2.svg'} className="img-fluid" alt="login-img"/>
                    </div>
                    <div className="col-md-7 col-lg-5 col-xl-5 offset-xl-1">
                        <form>
                            <button type="button" className="btn btn-primary btn-lg btn-block" onClick={() => login()}>!Accede!</button>
                        </form>
                    </div>
                </div>
            </div>
        </section>
    </div>);
}

