import { useEffect, useState } from 'react';
import './App.css';
import { Counter }  from './Counter'

function App() {
    const [categories, setCategories] = useState([]);

    useEffect(() => {
        fetch('https://localhost:7084/api/category').then(res => res.json()).then((data) => console.log(data))
    }, [])
    return <div><Counter /></div>
}

export default App;