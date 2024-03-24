import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import axios from 'axios';

const initialState = {
    categories: [],
    status: 'idle',
    error: null,
};

// Define an asynchronous thunk to fetch categories from the API
export const fetchCategories = createAsyncThunk('categories/fetchCategories', async () => {
    const response = await axios.get('https://localhost:7084/api/category');
    return response.data
})

const categorySlice = createSlice({
    name: 'category',
    initialState,
    reducers: {},
    extraReducers: builder => {
        builder
            .addCase(fetchCategories.pending, state => {
                state.status = 'loading';
            })
            .addCase(fetchCategories.fulfilled, (state, action) => {
                state.status = 'succeeded';
                state.categories = action.payload;
            })
            .addCase(fetchCategories.rejected, (state, action) => {
                state.status = 'failed';
                state.error = action.error.message;
                ;
            });
    },
});

export default categorySlice.reducer;