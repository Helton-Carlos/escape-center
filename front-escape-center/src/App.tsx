import { Routes, Route } from 'react-router-dom'
import { Login } from '@/views/Login'

import './App.css'

function App() {

  return (
    <>
     <Routes>
      <Route path="/" element={<h1>Home</h1>} />
      <Route path="/login" element={<Login />} />
     </Routes>
    </>
  )
}

export default App
