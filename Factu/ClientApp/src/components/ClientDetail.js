import React, { useEffect, useState } from 'react';
import Modal from 'react-bootstrap/Modal';
import Button from 'react-bootstrap/Button';

export const ClientDetail = ({ clients ,clientDetail, handleClose }) => {

    console.log(clientDetail);

    const SaveData = async (new_client) => {
        let body = JSON.stringify(new_client);

        const request = await fetch("/api/client/SaveClient", {
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
            <Modal.Header closeButton>
                <Modal.Title>{clientDetail.id ? clientDetail.name : 'Nuevo Cliente' }</Modal.Title>
            </Modal.Header>
            <Modal.Body>

            </Modal.Body>
            <Modal.Footer>
                <Button variant="secondary" onClick={handleClose}>
                    Cerrar
                </Button>
                <Button variant="primary" onClick={handleClose}>
                    Guardar Cambios
                </Button>
            </Modal.Footer>
        </div>
    );
}