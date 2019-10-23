export const createBook = (book) => {
    return (dispatch, getState, { getFirestore }) => {
        //make async call
        const firestore = getFirestore();
        const profile = getState().firebase.profile;
        const authorId = getState().firebase.auth.uid;
        firestore.collection('books').add({
            ...book,
            authorFirstName: profile.firstName,
            authorLastName: profile.lastName,
            authorId: authorId
        }).then(() => {
            dispatch({ type: 'CREATE_BOOK' });
        }).catch(err => {
            dispatch({ type: 'CREATE_BOOK_ERROR', err })
        })
    }
}

export const addToCart = (book) => {
    return (dispatch, getState, {getFirestore, getFirebase}) => {
        const firestore = getFirestore();
        const state = getState();
        firestore.collection('shopping_cart').add({              
                title: book.title,
                author: book.author,
                content: book.content,
                image: book.image,
                publishedon: book.publishedon        
        }).then(() => {
            dispatch({ type: 'ADD_BOOK_TOCART' });
        }).catch(err => {
            dispatch({ type: 'ADD_BOOK_TOCART_ERROR', err })
        })
    }
}

export const deleteFromCart = (id) => {
    return (dispatch, getState, {getFirestore, getFirebase}) => {
        const firestore = getFirestore();
        firestore.collection('shopping_cart').doc(id).delete().then(() => {
            dispatch({ type: 'DELETE_BOOK_TOCART' });
        }).catch(err => {
            dispatch({ type: 'DELETE_BOOK_TOCART_ERROR', err })
        })
    }
}