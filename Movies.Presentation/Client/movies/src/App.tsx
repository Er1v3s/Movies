import { Outlet, useLocation } from 'react-router-dom'
import './App.css'
import { Container } from 'semantic-ui-react';
import MovieTable from './components/movies/MovieTable.tsx';

function App() {

    const location = useLocation();

    return (
        <>
            {location.pathname === "/" ? <MovieTable /> : (
                <Container className="container-style">
                    <Outlet />
                </Container>
            )}
        </>
    )
}

export default App