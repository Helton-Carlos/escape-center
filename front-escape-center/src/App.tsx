import { Routes, Route, useLocation } from 'react-router-dom'
import { Dashboard } from '@/views/Dashboard'
import { Login } from '@/views/Login'
import { Header } from '@/layouts/Header'

function App() {
  const location = useLocation();

  return (
    <>
      {location.pathname !== '/login' && <Header />}

      <div className="p-4">
        <Routes>
        <Route path="/" element={<Dashboard />} />
        <Route path="/login" element={<Login />} />
      </Routes>
      </div>
    </>
  )
}

export default App
