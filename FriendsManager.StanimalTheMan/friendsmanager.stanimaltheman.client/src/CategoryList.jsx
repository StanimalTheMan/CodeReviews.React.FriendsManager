import { useEffect } from 'react';
import { useDispatch, useSelector } from "react-redux";
import { fetchCategories } from './categorySlice';

function CategoryList() {
    const dispatch = useDispatch();
    const categories = useSelector(state => state.category.categories);
    const status = useSelector(state => state.category.status);
    const error = useSelector(state => state.category.error);

    useEffect(() => {
        dispatch(fetchCategories());
    }, [dispatch]);

    if (status === 'loading') {
        return <div>Loading...</div>
    }

    if (status === 'failed') {
        return <div>Error: {error}</div>
    }

    return (
        <div>
            <h1>Categories</h1>
            <ul>
                {categories.map(category => (
                    <li key={category.id}>{category.name}</li>
                ))}
            </ul>
        </div>
    );
}

export default CategoryList;