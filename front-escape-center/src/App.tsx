import { Routes, Route } from 'react-router-dom'
import { Dashboard } from '@/views/Dashboard'
import { Login } from '@/views/Login'

function App() {
  return (
    <>
     <Routes>
      <Route path="/" element={<Dashboard />} />
      <Route path="/login" element={<Login />} />
     </Routes>
    </>
  )
}

export default App
