import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import Products from './Products/Index.jsx'
import Orders from './Orders/Index.jsx'
import Customers from './Customers/Index.jsx'
import Login from './Login/Index.jsx'
import Layout from './Shared/_Layout.jsx'
import {
  createBrowserRouter,
  RouterProvider
} from 'react-router-dom'

import './Styles/main.css'
import ErrorPage from './ErrorPage.jsx'


const router = createBrowserRouter([
  {
    path: "/",
    element: <Layout/>,
    errorElement:<ErrorPage/>,
    children:[
      {
        index:true,
        element:<Login/>
      },
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
      <RouterProvider router={router} />  
  </StrictMode>,
)
