import './Carreras.css'
import React, { useState } from 'react';
import axios from 'axios';

function Carrera ({carreras, setCarreras, isLoading, setAlumnos, alumnos}){
    
    const [nuevaCarrera, setNuevaCarrera] = useState({
        nombre: '',
        descripcion: '',
        cantidadAlumnos: 0,
    });
    const [carreraEditada, setCarreraEditada] = useState({
        nombre: '',
        descripcion: '',
    });
    const [editing, setEditing] = useState(false);
    
  
    const handleNuevaCarreraChange = (event) => {
        event.preventDefault();
        const { name, value}= event.target;
        setNuevaCarrera({ ...nuevaCarrera, [name]: value });
    };
  
    const handleAgregarCarrera = async () => {
      try {
        // Realiza una solicitud para crear una nueva carrera en la API
        const response = await axios.post('https://localhost:7056/api/Carrera', { 
            nombre: nuevaCarrera.nombre,
            descripcion: nuevaCarrera.descripcion,
            }); 
        // Agrega la nueva carrera a la lista de carreras locales
        let carreraResponse = {
            id: response.data.value.id,
            nombre: response.data.value.nombre,
            descripcion: response.data.value.descripcion,
            alumnos: []
        };
        setCarreras([...carreras, carreraResponse]);
        // Limpia el campo del formulario después de agregar la carrera
        setNuevaCarrera('');
      } catch (error) {
        console.error('Error al agregar una carrera:', error);
      }
    };

    const handleEditarCarrera = async (id) => {
        try {
            // Realiza una solicitud para editar una carrera en la API
            const response = await axios.put(`https://localhost:7056/api/Carrera`, { 
                id: id,
                nombre: carreraEditada.nombre,
                descripcion: carreraEditada.descripcion,
                }); 
            // Agrega la nueva carrera a la lista de carreras locales
            let long = carreras.find(carrera => carrera.id === id).alumnos; 
            let carreraResponse = {
                id: response.data.value.id,
                nombre: response.data.value.nombre,
                descripcion: response.data.value.descripcion,
                alumnos: long
            };
            let uptadedCarreras = carreras.map((carrera) => (carrera.id === id ? carreraResponse : carrera));
            setCarreras(uptadedCarreras);
            // Limpia el campo del formulario después de agregar la carrera
            setCarreraEditada('');
            setEditing(false);
        } catch (error) {
            console.error('Error al agregar una carrera:', error);
        }
    };

    const handleCarreraEditadaChange = (event) => {
        event.preventDefault();
        const { name, value}= event.target;
        setCarreraEditada({ ...carreraEditada, [name]: value });
    };
    
    const handleEliminarCarrera = async (id) => {
        try {
            await axios.delete(`https://localhost:7056/api/Carrera/${id}`);
            let updatedCarreras = carreras.filter((carrera) => carrera.id !== id);
            let updatedAlumnos = alumnos.filter((alumno) => alumno.carreraId !== id);
            setAlumnos(updatedAlumnos);
            setCarreras(updatedCarreras);
        }catch (error) {
            console.error('Error al eliminar una carrera:', error);
        }
    };
    
    return (
        <div className='mainDiv'>
            <h1>Carreras Universitarias</h1>
  
            {isLoading ? (
            <p>Cargando carreras...</p>
            ) : (
            <div className='tableDiv'>
            <table>
                <thead>
                    <tr>
                        <th>Nombre</th>
                        <th>Descripcion</th>
                        <th>Cantida Alumnos</th>
                        <th>Acciones</th>
                    </tr>
                </thead>
                <tbody>
                    {carreras.map((carrera) => (
                        <tr key={carrera.id}>
                            <td>{editing === carrera.id ? <input type="text" name="nombre" value={carreraEditada.nombre} onChange={handleCarreraEditadaChange} /> : carrera.nombre}</td>
                            <td>{editing === carrera.id ? <input type="text" name="descripcion" value={carreraEditada.descripcion} onChange={handleCarreraEditadaChange} /> : carrera.descripcion}</td>
                            <td>{carrera.alumnos != null ? carrera.alumnos.length : 0}</td>
                            <td>
                                {editing === carrera.id ? (
                                    <>
                                        <button onClick={() => handleEditarCarrera(carrera.id)}>Guardar</button>
                                        <button onClick={() => setEditing(false)}>Cancelar</button>
                                    </>
                                ) : (
                                    <>
                                        <button onClick={() => setEditing(carrera.id)}>Editar</button>
                                        <button className='buttonDelete' onClick={() => handleEliminarCarrera(carrera.id)}>Eliminar</button>
                                    </>
                                )}
                            </td>
                        </tr>
                    ))}
                </tbody>
            </table> 
            </div>
        )}
  
            <div>
                <h2>Agregar Nueva Carrera</h2>
                <form>
                    <input
                        type="text"
                        placeholder="Nombre de la carrera"
                        name='nombre'
                        value={nuevaCarrera.nombre}
                        onChange={handleNuevaCarreraChange}
                    />
                    <input
                        type="text"
                        placeholder="Descripcion de la carrera"
                        name='descripcion'
                        value={nuevaCarrera.descripcion}
                        onChange={handleNuevaCarreraChange}
                    />
                </form>
                <button onClick={handleAgregarCarrera}>Agregar</button>
            </div>
        </div>
    );
};

export default Carrera;
