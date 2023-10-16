import React, { useEffect, useState } from "react";
import axios from "axios";

export default function Alumnos({carreras, isLoading, alumnos, setAlumnos, isLoadingAlumnos}) {
    //console.log(carreras);
   
    const [nuevoAlumno, setNuevoAlumno] = useState({
        nombre: '',
        apellido: '',
        legajo: '',
        carreraId: 0,
    });
    const [alumnoEditado, setAlumnoEditado] = useState({
        nombre: '',
        apellido: '',
        legajo: '',
        carreraId: 0,
    });
    const [editing, setEditing] = useState(false);

    

    const handleNuevoAlumnoChange = (event) => {
        event.preventDefault();
        const { name, value}= event.target;
        setNuevoAlumno({ ...nuevoAlumno, [name]: value });
    };

    const handleAgregarAlumno = async () => {
        try {
            console.log(nuevoAlumno);
          // Realiza una solicitud para crear una nueva carrera en la API
          const response = await axios.post('https://localhost:7056/api/Alumno', nuevoAlumno); 
          // Agrega la nueva carrera a la lista de carreras locales
          let alumnoResponse = {
            id: response.data.value.id,
            nombre: response.data.value.nombre,
            apellido: response.data.value.apellido,
            legajo: response.data.value.legajo,
            carreraId: response.data.value.carreraId,
          };
          let updatedAlumnos = [...alumnos, alumnoResponse];
          setAlumnos(updatedAlumnos);
          console.log(alumnos)
          // Limpia el campo del formulario después de agregar la carrera
          setNuevoAlumno('');
        } catch (error) {
          console.error('Error al agregar una carrera:', error);
        }
      };
    
    const handleEditarAlumnoChange = (event) => {
        event.preventDefault();
        const { name, value}= event.target;
        setAlumnoEditado({ ...alumnoEditado, [name]: value });
    };

    const handleEditarAlumno = async (id) => {
        try {
            // Realiza una solicitud para editar una carrera en la API
            const response = await axios.put(`https://localhost:7056/api/Alumno`, { alumnoEditado }); 
            // Agrega la nueva carrera a la lista de carreras locales
            const alumnoResponse = {
                id: response.data.value.id,
                nombre: response.data.value.nombre,
                apellido: response.data.value.apellido,
                legajo: response.data.value.legajo,
                carreraId: response.data.value.CarreraId,
            };
            const updatedAlumnos = alumnos.map(alumno => {
                if (alumno.id === id) {
                  return alumnoResponse;
                }
                return alumno;
              });
            setAlumnos(updatedAlumnos);
            // Limpia el campo del formulario después de agregar la carrera
            setAlumnoEditado('');
        } catch (error) {
            console.error('Error al editar una carrera:', error);
        }
    };

    const handleEliminarAlumno = async (id) => {
        try {
            // Realiza una solicitud para editar una carrera en la API
            await axios.delete(`https://localhost:7056/api/Alumno/${id}`); 
            // Agrega la nueva carrera a la lista de carreras locales
            let updatedAlumnos = alumnos.filter((alumno) => alumno.id !== id);
            setAlumnos(updatedAlumnos);
            // Limpia el campo del formulario después de agregar la carrera
        } catch (error) {
            console.error('Error al editar una carrera:', error);
        }
    }

    return (
        <div className='mainDiv'>
            <h1>Alumnos</h1>
  
            {(isLoading || isLoadingAlumnos) ? (
            <p>Cargando alumnos...</p>
            ) : (
            <div className='tableDiv'>
                <table>
                    <thead>
                        <tr>
                            <th>Legajo</th>
                            <th>Nombre</th>
                            <th>Apellido</th>
                            <th>Carrera</th>
                            <th>Acciones</th>
                        </tr>
                    </thead>
                    <tbody>
                        {alumnos.map((alumno) => (
                            <tr key={alumno.id}>
                                <td>{editing === alumno.id ? <input type="text" name="legajo" value={alumnoEditado.legajo} onChange={handleEditarAlumnoChange} /> : alumno.legajo}</td>
                                <td>{editing === alumno.id ? <input type="text" name="nombre" value={alumnoEditado.nombre} onChange={handleEditarAlumnoChange} /> : alumno.nombre}</td>
                                <td>{editing === alumno.id ? <input type="text" name="apellido" value={alumnoEditado.apellido} onChange={handleEditarAlumnoChange} /> : alumno.apellido}</td>
                                <td>
                                    {editing === alumno.id ? (
                                        <input type="text" name="nombre" value={alumnoEditado && alumnoEditado.nombre} onChange={handleEditarAlumnoChange} />
                                    ) : (
                                        carreras.length === 0 ? (
                                            // Maneja el caso cuando carreras está vacío
                                            "Carreras vacías"
                                        ) : (
                                            carreras.find(carrera => carrera.id === alumno.carreraId).nombre
                                        )
                                    )}
                                </td>
                                <td>
                                    {editing === alumno.id ? (
                                        <>
                                            <button onClick={() => handleEditarAlumno(alumno.id)}>Guardar</button>
                                            <button onClick={() => setEditing(false)}>Cancelar</button>
                                        </>
                                    ) : (
                                        <>
                                            <button onClick={() => setEditing(alumno.id)}>Editar</button>
                                            <button className='buttonDelete' onClick={() => handleEliminarAlumno(alumno.id)}>Eliminar</button>
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
                <h2>Agregar Nuevo Alumno</h2>
                <form>
                    <input
                        type="text"
                        placeholder="Legajo del alumno"
                        name='legajo'
                        value={nuevoAlumno.legajo}
                        onChange={handleNuevoAlumnoChange}
                    />
                    <input
                        type="text"
                        placeholder="Nombre del alumno"
                        name='nombre'
                        value={nuevoAlumno.nombre}
                        onChange={handleNuevoAlumnoChange}
                    />
                    <input
                        type="text"
                        placeholder="Apellido del alumno"
                        name='apellido'
                        value={nuevoAlumno.apellido}
                        onChange={handleNuevoAlumnoChange}
                    />
                    <select name="carreraId" onChange={handleNuevoAlumnoChange}>
                        <option value="">carreras</option>
                        {carreras.map((carrera) => (
                            <option value={carrera.id} key={carrera.id}>{carrera.nombre}</option>
                        ))}
                    </select>
                </form>
                <button onClick={handleAgregarAlumno}>Agregar</button>
            </div>
        </div>
    )
}