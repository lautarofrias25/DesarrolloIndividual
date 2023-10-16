import { useState, useEffect } from 'react';
import axios from 'axios';

export default function useCarrera() {
    const [carreras, setCarreras] = useState([]);
    const [isLoading, setIsLoading] = useState(false);
    const [alumnos, setAlumnos] = useState([]);
    const [isLoadingAlumnos, setIsLoadingAlumnos] = useState(false);

    useEffect(() => {
        // Función para cargar las carreras desde la API
          const cargarCarreras = async () => {
          try {
              setIsLoading(true);
              const response = await axios.get('https://localhost:7056/api/Carrera');
              await setCarreras(response.data.value);
          } catch (error) {
              console.error('Error al cargar carreras:', error);
          } finally {
              setIsLoading(false);
          }
        };
    
        cargarCarreras();
        
    }, [alumnos]);

    useEffect(() => {
        const getAlumnos = async () => {
            try {
                setIsLoadingAlumnos(true);
                const response = await axios.get("https://localhost:7056/api/Alumno")
                setAlumnos(response.data.value)
            } catch (error) {
                console.error("Error al obtener alumnos", error)
            }
            finally {
                setIsLoadingAlumnos(false)
            }
        }
        getAlumnos()
    }, []);

    
      
    return {carreras, setCarreras, isLoading, alumnos, isLoadingAlumnos, setAlumnos};
};

