import { useEffect, useState } from 'react';
import './App.css';

function App() {
    const [categories, setCategories] = useState([]);

    useEffect(() => {
        fetch('https://localhost:7084/api/category').then(res => res.json()).then((data) => console.log(data))
    }, [])
    return <div>App</div>
}

export default App;