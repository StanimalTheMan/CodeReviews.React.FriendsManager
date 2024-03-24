import { configureStore } from '@reduxjs/toolkit'
import categoryReducer from './categorySlice'
import counterReducer from './counterSlice'

export default configureStore({
    reducer: {
        category: categoryReducer,
        counter: counterReducer
    }
})