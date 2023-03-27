import { createContext } from 'react';

export const UserContext = createContext({
    Id: null,
    Email: "",
    Name: "",
    Apellido: "",
    Fullname: "",
    Logged: false,
    Token: ""
});