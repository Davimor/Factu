import React, { useEffect, useState } from 'react';

export const Datos = () => {

    const [entidadesBancarias, setEntidades] = useState([]);

    const load = async () => {
        const request = await fetch("/api/datos/GetEntidadesBancarias");
        if (request.ok) {
            setEntidades(await request.json());
        }
    }

    load();

    return (
        <div>
            <h4>Datos Entidad</h4>
            <form id="contactForm" data-sb-form-api-token="API_TOKEN">
                <div className="form-floating mb-3">
                    <input className="form-control" id="nombre" type="text" placeholder="Nombre" data-sb-validations="required" />
                    <label htmlFor="nombre">Nombre</label>
                    <div className="invalid-feedback" data-sb-feedback="nombre:required">Nombre is required.</div>
                </div>
                <div className="form-floating mb-3">
                    <input className="form-control" id="cif" type="text" placeholder="CIF" data-sb-validations="required" />
                    <label htmlFor="cif">CIF</label>
                    <div className="invalid-feedback" data-sb-feedback="cif:required">CIF is required.</div>
                </div>
                <div className="form-floating mb-3">
                    <input className="form-control" id="direccion" type="text" placeholder="Direccion" data-sb-validations="required" />
                    <label htmlFor="direccion">Direccion</label>
                    <div className="invalid-feedback" data-sb-feedback="direccion:required">Direccion is required.</div>
                </div>
                <div className="form-floating mb-3">
                    <select className="form-select" id="entidadBancaria" aria-label="Entidad Bancaria">
                        {
                            entidadesBancarias.map((x) =>
                                <option key="{ x.id }">{x.name}</option>
                            )
                        }
                    </select>
                    <label htmlFor="entidadBancaria">Entidad Bancaria</label>
                </div>
                <div className="form-floating mb-3">
                    <input className="form-control" id="ccc" type="text" placeholder="CCC" data-sb-validations="required" />
                    <label htmlFor="ccc">CCC</label>
                    <div className="invalid-feedback" data-sb-feedback="ccc:required">CCC is required.</div>
                </div>
                <div className="d-none" id="submitErrorMessage">
                    <div className="text-center text-danger mb-3">Error sending message!</div>
                </div>
                <div className="d-grid">
                    <button className="btn btn-primary btn-lg disabled" id="submitButton" type="submit">Guardar</button>
                </div>
            </form>

        </div>
    );
}
