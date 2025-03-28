import { createRoot } from 'react-dom/client'
import 'semantic-ui-css/semantic.min.css'
import './App.css'
import { router } from './router/Routes'
import { RouterProvider } from 'react-router-dom'

createRoot(document.getElementById('root')!).render(
    <RouterProvider router={router} />
)
