import './App.css'
import Carrera from './components/Carreras'
import Alumno from './components/Alumnos'
import useCarrera from './hooks/useCarrera'


export default function App() {
  const {carreras, setCarreras, isLoading, isLoadingAlumnos, alumnos, setAlumnos} = useCarrera();
  return (
    <div className='appDiv'>
      <Carrera carreras={carreras} setCarreras={setCarreras} isLoading={isLoading} setAlumnos={setAlumnos} alumnos={alumnos} />
      <Alumno carreras={carreras} isLoading={isLoading} alumnos={alumnos} setAlumnos={setAlumnos} isLoadingAlumnos={isLoadingAlumnos} />
    </div>
  )
}

