import React, { useEffect, useState } from 'react';
import { ClientDetail } from './ClientDetail';
import Modal from 'react-bootstrap/Modal';

let allClients = [];
export const Clientes = () => {

    const [clients, setClients] = useState([]);
    const [show, setShow] = useState(false);
    const [clientDetail, setclientDetail] = useState({});

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const GetClientes = async () => {
        const request = await fetch("/api/client/GetClients");
        if (request.ok) {
            allClients = await request.json();
            setClients(allClients);
        }
    }

    useEffect(() => {
        GetClientes();
    }, []);


    const ShowClientDetails = (client) => {
        setclientDetail(client);
        handleShow();
    };

    const NewClient = () => {
        setclientDetail({});
        handleShow();
    };

    const search = (e) => {
        var sch = e.target.value.toLowerCase();

        let found = allClients.filter(client => {
            console.log(client.name.toLowerCase() + " - " + sch + " Result: " + client.name.toLowerCase().includes(sch));
            return client.name.toLowerCase().includes(sch)
                || client.idFiscal.toLowerCase().includes(sch)
                || client.direccion.toLowerCase().includes(sch);
        });

        setClients(found);
    }


    return (
        <div>
            <h4>Clientes</h4>
            <button className="btn btn-outline-secondary" onClick={() => NewClient()}>Nuevo Cliente</button>
            <div className="form-floating mb-3 float-end">
                <input className="form-control" id="search" type="text" placeholder="Busqueda" data-sb-validations="required" name="search" onChange={search} />
                <label htmlFor="search">Busqueda</label>
            </div>

            <table className="table table-striped table-hover table-bordered">
                <thead>
                    <tr>
                        <th>Nombre</th>
                        <th>IdFiscal</th>
                        <th>Direccion</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        clients.map((x, i) => {
                            return (<tr key={i} onDoubleClick={() => { ShowClientDetails(x) }}>
                                <td>{x.name}</td>
                                <td>{x.idFiscal}</td>
                                <td>{x.direccion}</td>
                            </tr>)
                        })
                    }
                </tbody>
            </table>

            <Modal show={show} onHide={handleClose}>
                <ClientDetail clients={clients} clientDetail={clientDetail} handleClose={handleClose} />
            </Modal>

        </div>
    );
}
