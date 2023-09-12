#pragma once
#include <limits>

namespace geo
{
	template<class T>
	class Point
	{
		T _x;
		T _y;
	public:
		T X() const { return _x; }
		T Y() const { return _y; }

		Point(const T x, const T y) :_x(x), _y(y)
		{}
		Point() :_x(0), _y(0)
		{}

		static Point<T> Empty() { return { (std::numeric_limits<T>::max)(),(std::numeric_limits<T>::max)() }; }

		bool IsEmpty() const { return !(_x < (std::numeric_limits<T>::max)() || _y < (std::numeric_limits<T>::max)()); }
	};


}

