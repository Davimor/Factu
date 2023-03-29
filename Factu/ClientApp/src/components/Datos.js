import React, { useEffect, useState } from 'react';

export const Datos = () => {

    const [entidadesBancarias, setEntidades] = useState([]);
    const [entity, setEntity] = useState({});

    const GetEntidadesBancarias = async () => {
        const request = await fetch("/api/datos/GetEntidadesBancarias");
        if (request.ok) {
            setEntidades(await request.json());
        }
    }

    const GetDatos = async () => {
        const request = await fetch("/api/datos/GetDatos");
        if (request.ok) {
            let data = await request.json();
            setEntity(data);
        }
    }

    useEffect(() => {
        GetEntidadesBancarias();
        GetDatos();
    }, []);

    const onSubmit = (e) => {
        let datos = e.target;

        let new_entity = {
            name: datos.name.value,
            idFiscal: datos.idFiscal.value,
            direccion: datos.direccion.value,
            entidadBancaria: datos.entidadBancaria.value,
            CCC: datos.CCC.value
        };

        setEntity(new_entity);
        SaveData(new_entity);


        e.preventDefault();
    };


    const SaveData = async (new_entity) => {
        let body = JSON.stringify(new_entity);

        const request = await fetch("/api/datos/SetDatos", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: body
        });

        if (request.ok) {
            let response = await request.json();
        }
    }


    return (
        <div>
            <h4>Datos Entidad - {entity.name}</h4>
            <form id="datosForm" onSubmit={onSubmit} >
                <div className="form-floating mb-3">
                    <input className="form-control" id="nombre" type="text" placeholder="Nombre" data-sb-validations="required" name="name" defaultValue={entity.name} />
                    <label htmlFor="nombre">Nombre</label>
                    <div className="invalid-feedback" data-sb-feedback="nombre:required">Nombre is required.</div>
                </div>
                <div className="form-floating mb-3">
                    <input className="form-control" id="cif" type="text" placeholder="CIF" data-sb-validations="required" name="idFiscal" defaultValue={entity.idFiscal} />
                    <label htmlFor="cif">CIF</label>
                    <div className="invalid-feedback" data-sb-feedback="cif:required">CIF is required.</div>
                </div>
                <div className="form-floating mb-3">
                    <input className="form-control" id="direccion" type="text" placeholder="Direccion" data-sb-validations="required" name="direccion" defaultValue={entity.direccion} />
                    <label htmlFor="direccion">Direccion</label>
                    <div className="invalid-feedback" data-sb-feedback="direccion:required">Direccion is required.</div>
                </div>
                <div className="form-floating mb-3">
                    <select className="form-select" id="entidadBancaria" aria-label="Entidad Bancaria" name="entidadBancaria" defaultValue={entity.entidadBancaria}>
                        {
                            entidadesBancarias.map((x) =>
                                /* (entity.entidadBancaria === x.name) ? <option key={x.id} selected>{x.name}</option> : <option key={x.id}  >{x.name}</option>*/
                                <option key={x.name} value={x.name}>{x.name}</option>
                            )
                        }
                    </select>
                    <label htmlFor="entidadBancaria">Entidad Bancaria</label>
                </div>
                <div className="form-floating mb-3">
                    <input className="form-control" id="ccc" type="text" placeholder="CCC" data-sb-validations="required" name="CCC" defaultValue={entity.ccc} maxLength="20" minLength="20" />
                    <label htmlFor="ccc">CCC</label>
                    <div className="invalid-feedback" data-sb-feedback="ccc:required">CCC is required.</div>
                </div>
                <div className="d-none" id="submitErrorMessage">
                    <div className="text-center text-danger mb-3">Error enviando mensaje</div>
                </div>
                <div className="d-grid">
                    <button className="btn btn-primary btn-lg" id="submitButton" type="submit" >Guardar</button>
                </div>
            </form>

        </div>
    );
}
