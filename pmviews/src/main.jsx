import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import Products from './products.jsx'
import Orders from './orders.jsx'
import Customers from './customers.jsx'
import {
  createBrowserRouter,
  RouterProvider
} from 'react-router-dom'


import Layout from './Shared/_Layout.jsx'
import './index.css'
import ErrorPage from './ErrorPage.jsx'


const router = createBrowserRouter([
  {
    path: "/",
    element: <Layout/>,
    errorElement:<ErrorPage/>,
    children:[
      {
        path: "/products",
        element: <Products/>
      },
      {
        path: "/customers",
        element: <Customers/>
      },
      {
        path: "/orders",
        element: <Orders/>
      }],
  },
 
]);

createRoot(document.getElementById('root')).render(

  <StrictMode>
    <RouterProvider router={router}/>
  </StrictMode>,
)
